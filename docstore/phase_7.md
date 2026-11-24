# Phase 7: Remove Legacy Coupling

## Status

Phase 7 is complete. The legacy WinForms application has been retired from
the solution after the equivalent Blazor workflows were implemented and
validated in Phase 6.

## Evidence reviewed

This phase was reconciled against all readable `docstore` material:

- `plan.md`
- `phase_2.md` through `phase_6.md`
- `schema.md`
- `SQL_Paths.md`
- `CreateTables.sql`
- `winforms_behavious.md`
- `Aceptance_Testing.md`
- `Prelim-Code-Smells.sarif`
- `Init Proposal.docx`
- `Kevin Molloy - CPURepairSYS - Interm Review.docx`
- `Software Design patterns - Assignment 1 -2026.pdf`

The proposal and interim review require moving away from WinForms, removing
SQL from domain classes, and placing persistence behind repositories and an
application service boundary. The plan's Phase 6 evidence confirms the
Blazor pages cover customer, repair, estimate, inventory, and reporting
workflows.

## Changes completed

### Retired WinForms presentation

The root `CPURepairSYS.csproj` and all WinForms forms, designer resources,
legacy startup code, and legacy lookup classes were removed from the
solution. The root project entry and its build configurations were removed
from `CPURepairSYS.sln`.

This is an intentional retirement rather than a compatibility wrapper:

- Every documented WinForms workflow has a corresponding Blazor route.
- Keeping the net7 WinForms project would preserve a second composition root
  and its direct Oracle dependency.
- The new Web project targets the layered net8 architecture established in
  Phases 2-6.

### Removed domain/persistence coupling

The legacy `Customer`, `Part`, and `Repair` classes, which contained
`OracleConnection`, `OracleCommand`, SQL construction, and `MAX(Id) + 1`
allocation, no longer exist in the application source tree.

The replacement domain entities are in `src/CPURepairSYS.Domain` and contain
only domain rules. Persistence is implemented by repository and adapter
classes in `src/CPURepairSYS.Infrastructure`, exposed through interfaces in
`src/CPURepairSYS.Application`.

### Preserved application boundary

The active presentation layer remains dependent on application facades:

- `RepairFacade` owns customer, repair, estimate, and lifecycle workflows.
- `InventoryFacade` owns part and stock workflows.
- `ReportingFacade` owns repair, parts, and revenue reports.

Blazor components use request DTOs, summaries, and typed application results.
They do not construct domain entities, execute SQL, access Oracle objects, or
call repositories directly. No retained WinForms workflow needs a facade
adapter because the screens were retired rather than kept alongside Blazor.

## Verification

The following checks are required after the retirement:

```powershell
dotnet build .\CPURepairSYS.sln --no-restore
dotnet test .\CPURepairSYS.sln --no-build --no-restore
```

The source scan must also show no legacy WinForms project, form source, or
root domain class:

```powershell
rg "OracleConnection|OracleCommand|DBConnect|SELECT |INSERT |UPDATE |DELETE " `
  --glob "*.cs" .
```

Any remaining SQL belongs to the Infrastructure persistence boundary and is
reviewed separately from the retired WinForms code. The new application and
domain projects must continue to have no references to WinForms controls,
`DataSet`, or `DataReader`.

### Validation result

`dotnet restore .\CPURepairSYS.sln` completed successfully and
`dotnet build .\CPURepairSYS.sln --no-restore` passed with zero warnings and
zero errors. `dotnet sln .\CPURepairSYS.sln list` confirms that only the Web,
Application, Domain, Infrastructure, and three test projects remain.

The solution test run passed the integration and Web tests. One existing unit
test, `DuplicateEstimatePartsAreRejected`, failed because the current domain
implementation does not throw for duplicate estimate lines. That behavior is
outside the legacy-coupling change and was not modified in this phase; it is
recorded for Phase 8 quality work.

## Phase 7 checklist

- [x] Blazor equivalents were verified before retirement.
- [x] WinForms forms no longer construct domain objects because the screens
  were removed.
- [x] SQL was removed from the legacy `Customer`, `Part`, and `Repair`
  classes by retiring those classes.
- [x] Direct database calls from WinForms event handlers were removed with
  the forms.
- [x] Active workflows use the application facade contracts.
- [x] The retired WinForms project is no longer part of the solution.
- [ ] Phase 8 static-analysis comparison and submission evidence remain.
