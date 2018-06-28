import axios from 'axios';
import { Constant } from '../common/Constant';
import { Authentication } from './Authentication';
import { Promise } from 'es6-promise';

export class DAL {

    private static makeRequest(route: string, method: string, data?: any) {
        return new Promise((resolve: any, reject: any) => {
            axios({
                url: `${Constant.apiHostURL}${Constant.apiURL}${route}`, method: method, data: data, headers: {
                    'Authorization': 'bearer ' + Authentication.getAcessToken(),
                    'Content-Type': 'application/json',
                    withCredentials: true
                }
            }).then((res) => {
                resolve(res);
            }, (err) => {
                reject(err);
            });
        })
    }

    private static get(route: string) {
        return this.makeRequest(route, "GET");
    }

    private static post(route: string, data: any) {
        return this.makeRequest(route, "POST", data);
    }

    private static put(route: string, data: any) {
        return this.makeRequest(route, "PUT", data);
    }

    public static getCategories() {
        return DAL.get('/GetAllCategories');
    }

    public static getTags() {
        return DAL.get('/GetAllTags');
    }

    public static getBookmarks() {
        return DAL.get('/GetAllBookmarks');
    }

    public static getLastBookmarks(bookmarksNumber: number) {
        return DAL.get('/GetLastBookmarks/' + bookmarksNumber.toString());
    }

    public static getSearchedBookmarks(searchQuery: string) {
        return DAL.get('/GetBookmarksBySearchQuery/' + searchQuery);
    }

    public static checkBookmarkExists(URL: any) {
        return DAL.post('/CheckBookmarkExists/', URL);
    }

    public static addBookmark(data: any) {
        return DAL.post('/AddBookmark', data);
    }

    public static updateBookmark(data: any) {
        return DAL.put('/UpdateBookmark', data);
    }

    public static getUsers() {
        return DAL.get('/GetAllUsers');
    }

    public static getViews() {
        return DAL.get('/GetAllViews');
    }

    public static getClaps() {
        return DAL.get('/GetAllClaps');
    }
}