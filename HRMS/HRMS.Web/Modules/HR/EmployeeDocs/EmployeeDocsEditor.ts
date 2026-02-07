import { Decorators } from '@serenity-is/corelib';
import { GridEditorBase } from '../../Common/Helpers/GridEditorBase';
import { EmployeeDocsColumns, EmployeeDocsRow } from '../../ServerTypes/HR';
import { EmployeeDocsEditDialog } from './EmployeeDocsEditDialog';

declare var Q: any;

@Decorators.registerEditor('HRMS.HR.EmployeeDocsEditor')
export class EmployeeDocsEditor extends GridEditorBase<EmployeeDocsRow> {
    protected override getColumnsKey() { return EmployeeDocsColumns.columnsKey; }
    protected override getDialogType() { return EmployeeDocsEditDialog; }
    protected override getRowDefinition() { return EmployeeDocsRow; }

    constructor(container: any) {
        super(container);
    }

    protected override getAddButtonCaption() {
        return "Add Document";
    }

    protected override validateEntity(row: EmployeeDocsRow, id: number) {
        if (!super.validateEntity(row, id))
            return false;

        row.DocumentType = Q.toId(row.DocumentType);

        return true;
    }
}
