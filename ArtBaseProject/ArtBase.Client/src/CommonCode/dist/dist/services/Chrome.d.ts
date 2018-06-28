/// <reference types="chrome" />
import { Promise } from 'es6-promise';
export interface ITabInfo {
    title: string;
    url: string;
}
export declare class Chrome {
    static getTabInfo(): Promise<ITabInfo>;
    static getCookie(name: any): Promise<chrome.cookies.Cookie>;
}
