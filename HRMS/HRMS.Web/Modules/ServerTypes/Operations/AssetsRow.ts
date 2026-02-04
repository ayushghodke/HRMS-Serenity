import { fieldsProxy, getLookup, getLookupAsync } from "@serenity-is/corelib";
import { AssetStatus } from "./AssetStatus";
import { AssetType } from "./AssetType";

export interface AssetsRow {
    AssetId?: number;
    AssetName?: string;
    SerialNumber?: string;
    AssetType?: AssetType;
    Status?: AssetStatus;
    AssignedTo?: number;
    PurchaseDate?: string;
    Cost?: number;
    Description?: string;
    AssignedToFullName?: string;
}

export abstract class AssetsRow {
    static readonly idProperty = 'AssetId';
    static readonly nameProperty = 'AssetName';
    static readonly localTextPrefix = 'Operations.Assets';
    static readonly lookupKey = 'Operations.Assets';

    /** @deprecated use getLookupAsync instead */
    static getLookup() { return getLookup<AssetsRow>('Operations.Assets') }
    static async getLookupAsync() { return getLookupAsync<AssetsRow>('Operations.Assets') }

    static readonly deletePermission = 'Operations:Assets';
    static readonly insertPermission = 'Operations:Assets';
    static readonly readPermission = 'Operations:Assets';
    static readonly updatePermission = 'Operations:Assets';

    static readonly Fields = fieldsProxy<AssetsRow>();
}