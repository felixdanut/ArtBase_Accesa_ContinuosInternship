import * as React from 'react';
import './LoginForm.css';
import { Constant } from 'artbase-common';

export interface ILoginFormProps {
    title: string;
}

class LoginForm extends React.Component<ILoginFormProps, any> {
    openLoginPage = () => {
        window.open(Constant.apiHostURL, "_blank");
    };

    render() {
        return (
            <div className='artB-LoginForm'>
                <p>Please log in to continue!</p>
                <button className='artB-loginBtn artB-loginBtn--google' onClick={this.openLoginPage}> {this.props.title} </button>
            </div>
        );
    }
}

export default LoginForm