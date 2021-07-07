export interface IPaginationParams {
    // PageIndex = 0;
    // NextPageLink = '';
    // PageSize = 0;
    // PreviousPageLink = '';
    // TotalCount = 0;
    // TotalPage = 0;
    PageIndex: number
    NextPageLink: string
    PageSize: number
    PreviousPageLink: string
    TotalCount: number
    TotalPage: number
}

export class PaginationParams implements IPaginationParams {
    PageIndex = 0;
    NextPageLink = '';
    PageSize = 6;
    PreviousPageLink = '';
    TotalCount = 0;
    TotalPage = 0;
}