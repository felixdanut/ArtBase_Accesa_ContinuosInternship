import { Promise } from 'es6-promise';
export declare class DAL {
    private static makeRequest;
    private static get;
    private static post;
    private static put;
    static getCategories(): Promise<{}>;
    static getTags(): Promise<{}>;
    static getBookmarks(): Promise<{}>;
    static getLastBookmarks(bookmarksNumber: number): Promise<{}>;
    static getSearchedBookmarks(searchQuery: string): Promise<{}>;
    static checkBookmarkExists(URL: any): Promise<{}>;
    static addBookmark(data: any): Promise<{}>;
    static updateBookmark(data: any): Promise<{}>;
    static getUsers(): Promise<{}>;
    static getViews(): Promise<{}>;
    static getClaps(): Promise<{}>;
}
