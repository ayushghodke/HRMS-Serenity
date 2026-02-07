import { registerEnum } from "@serenity-is/corelib";

export enum DocumentKind {
    Aadhar = 1,
    PAN = 2,
    Resume = 3,
    OfferLetter = 4,
    Other = 5
}
registerEnum(DocumentKind, 'HRMS.HR.DocumentKind');