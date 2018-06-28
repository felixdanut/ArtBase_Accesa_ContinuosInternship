import { Promise } from 'es6-promise';
import { Constant } from '../common/Constant';

///<reference types="chrome"/>

export interface ITabInfo {
    title: string;
    url: string;
}

export class Chrome {
    public static getTabInfo(): Promise<ITabInfo> {
        return new Promise<ITabInfo>((resolve, reject) => {
            chrome.tabs.query({
                active: true,
                currentWindow: true
            }, (tabs) => {
                resolve({ title: tabs[0].title, url: tabs[0].url });
            });
        })
    }

    public static getCookie(name: any): Promise<chrome.cookies.Cookie> {
        return new Promise<chrome.cookies.Cookie>((resolve, reject) => {
            chrome.cookies.get({ url: Constant.tokenURL, name: name }, (cookie) => {
                resolve(cookie);
            });
        });
    }
}