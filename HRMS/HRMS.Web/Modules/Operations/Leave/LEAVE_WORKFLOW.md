# Leave Workflow and Balance Ownership

## Workflow Stages

- `Pending (0)`: Leave request submitted by employee.
- `ManagerApproved (1)`: First-level approval completed by reporting manager.
- `Approved (2)`: Final approval completed by HR/Admin.
- `Rejected (-1)`: Rejected by manager (first level) or HR/Admin (final level).
- `Cancelled (-2)`: Cancelled by the same employee while request is still pending.

## Transition Rules

- Manager can approve/reject only when `FinalStatus = Pending`.
- HR/Admin can approve/reject only when `FinalStatus = ManagerApproved`.
- Employee can cancel only when:
  - leave is `Pending`
  - actor employee id matches leave employee id.
- Finalized requests (`Approved`, `Rejected`, `Cancelled`) are immutable.

## Remarks Rules

- Rejection remarks are mandatory.
- Cancellation remarks are mandatory.
- Approval remarks are optional and stored in approval audit entries.

## Audit Integrity

- `LeaveApprovals` are system-generated workflow logs.
- Manual create/update/delete operations are blocked.

## Canonical Balance Model

- `EmployeeLeaveProfiles` is the canonical source of leave balances.
- `LeaveBalances` is a derived projection for compatibility/reporting.
- Recalculation updates profile usage first, then syncs projection rows.
