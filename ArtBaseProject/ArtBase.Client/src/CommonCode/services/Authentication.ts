import { Constant } from '../common/Constant';
import { Promise } from 'es6-promise';
import { Chrome } from './Chrome';

export class Authentication {
    public static getAcessToken() {
        return new Promise<string>((resolve: any, reject: any) => {
            Chrome.getCookie(Constant.tokenName).then((cookie: any) => {
                if (cookie) {
                    resolve(cookie.value);
                }
                resolve('');
            });
        })

    }
}