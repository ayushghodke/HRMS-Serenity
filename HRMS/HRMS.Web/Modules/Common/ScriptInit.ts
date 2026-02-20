import { Config, EntityDialog, ErrorHandling, TranslationConfig } from "@serenity-is/corelib";
import { gridDefaults } from "@serenity-is/sleekgrid";
import flatpickr from "flatpickr";
import "flatpickr/dist/l10n";
import { getLanguageList } from "./Helpers/LanguageList";
import DOMPurify from "dompurify";

Config.rootNamespaces.push('HRMS');
TranslationConfig.getLanguageList = getLanguageList;
gridDefaults.sanitizer = (globalThis.DOMPurify = DOMPurify).sanitize;

let culture = (document.documentElement?.lang || 'en').toLowerCase();
if (flatpickr.l10ns[culture]) {
    flatpickr.localize(flatpickr.l10ns[culture]);
} else {
    culture = culture.split('-')[0];
    flatpickr.l10ns[culture] && flatpickr.localize(flatpickr.l10ns[culture]);
}

window.onerror = ErrorHandling.runtimeErrorHandler;
window.addEventListener('unhandledrejection', ErrorHandling.unhandledRejectionHandler);

const entityDialogProto = EntityDialog.prototype as any;
const saveUpdatePatchFlag = '__hrmsSaveUpdateButtonsPatched';

if (!entityDialogProto[saveUpdatePatchFlag]) {
    const originalGetToolbarButtons = entityDialogProto.getToolbarButtons;

    entityDialogProto.getToolbarButtons = function (...args: any[]) {
        const buttons = originalGetToolbarButtons.apply(this, args);

        const saveAndCloseButton = buttons.find((button: any) =>
            (button.cssClass || '').indexOf('save-and-close-button') >= 0);
        if (saveAndCloseButton) {
            saveAndCloseButton.title = 'Update';
            saveAndCloseButton.hint = 'Update';
        }

        const applyChangesButton = buttons.find((button: any) =>
            (button.cssClass || '').indexOf('apply-changes-button') >= 0);
        if (applyChangesButton) {
            applyChangesButton.title = 'Save';
            applyChangesButton.hint = 'Save';
        }

        return buttons;
    };

    entityDialogProto[saveUpdatePatchFlag] = true;
}
