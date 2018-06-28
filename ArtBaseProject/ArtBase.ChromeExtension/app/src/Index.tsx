import * as React from 'react';
import * as ReactDOM from 'react-dom';

import { LoadingSpinner, Authentication } from 'artbase-common';
import LoginForm from './components/Login/LoginForm';
import ArtBaseTabs from './components/ArtBaseTabs';

export interface IExtensionRootProps { }

export interface IExtensionRootState {
    userAuthenticated: boolean;
    checkedAuthentication: boolean;
}

export class ExtensionRoot extends React.Component<IExtensionRootProps, IExtensionRootState> {

    constructor(props: IExtensionRootProps) {
        super(props);
        this.state = {
            userAuthenticated: false,
            checkedAuthentication: false,
        };
    }

    componentDidMount() {
        Authentication.getAcessToken().then((token: string) => this.setState({ checkedAuthentication: true, userAuthenticated: !!token }));
    }

    render() { 
        if (this.state.checkedAuthentication) {
            if (this.state.userAuthenticated) {
                return <ArtBaseTabs />;
            }
            return <LoginForm title='Login with Google' />;
        }

        return <LoadingSpinner />;
    }
}

ReactDOM.render(
    <ExtensionRoot />,
    document.getElementById('app')
);