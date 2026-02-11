import { Decorators, EntityGrid } from '@serenity-is/corelib';
import { EmployeeSalaryDetailsColumns, EmployeeSalaryDetailsRow, EmployeeSalaryDetailsService } from '../../ServerTypes/HR';
import { GridEditorBase } from '../../Common/Helpers/GridEditorBase';
import { GridEditorDialog } from '../../Common/Helpers/GridEditorDialog';

@Decorators.registerClass('HRMS.HR.EmployeeSalaryDetailsEditor')
export class EmployeeSalaryDetailsEditor extends GridEditorBase<EmployeeSalaryDetailsRow> {
    protected override getColumnsKey() { return EmployeeSalaryDetailsColumns.columnsKey; }
    protected override getLocalTextPrefix() { return EmployeeSalaryDetailsRow.localTextPrefix; }
    protected override getDialogType() { return EmployeeSalaryDetailsEditDialog; }

    constructor(container: JQuery) {
        super(container);
    }
}

@Decorators.registerClass('HRMS.HR.EmployeeSalaryDetailsEditDialog')
export class EmployeeSalaryDetailsEditDialog extends GridEditorDialog<EmployeeSalaryDetailsRow> {
    protected override getFormKey() { return 'HR.EmployeeSalaryDetails'; }
    protected override getLocalTextPrefix() { return EmployeeSalaryDetailsRow.localTextPrefix; }
}
