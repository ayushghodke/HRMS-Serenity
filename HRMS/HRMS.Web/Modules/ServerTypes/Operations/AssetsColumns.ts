import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { AssetsRow } from "./AssetsRow";
import { AssetType } from "./AssetType";

export interface AssetsColumns {
    AssetId: Column<AssetsRow>;
    AssetName: Column<AssetsRow>;
    SerialNumber: Column<AssetsRow>;
    AssetType: Column<AssetsRow>;
    Status: Column<AssetsRow>;
    AssignedToFullName: Column<AssetsRow>;
    PurchaseDate: Column<AssetsRow>;
    Cost: Column<AssetsRow>;
}

export class AssetsColumns extends ColumnsBase<AssetsRow> {
    static readonly columnsKey = 'Operations.Assets';
    static readonly Fields = fieldsProxy<AssetsColumns>();
}

[AssetType]; // referenced types