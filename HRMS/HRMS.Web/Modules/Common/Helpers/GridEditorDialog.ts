import { Decorators, EntityDialog } from '@serenity-is/corelib';

@Decorators.registerClass('HRMS.Common.GridEditorDialog')
export class GridEditorDialog<TEntity> extends EntityDialog<TEntity, any> {
    protected override getToolbarButtons() {
        var buttons = super.getToolbarButtons();
        buttons.push({
            title: "Apply",
            cssClass: "apply-changes-button",
            onClick: () => this.saveHandler({}, (response) => {
                this.loadResponse(response);
            })
        });
        return buttons;
    }

    protected override getService() { return null; }

    public onSave: (options: any, callback: (response: any) => void) => void;

    protected override saveHandler(options: any, callback: (response: any) => void) {
        this.onSave && this.onSave(options, callback);
    }

    protected saveRequest(options: any, callback: (response: any) => void) {
        this.onSave && this.onSave(options, callback);
    }
}
