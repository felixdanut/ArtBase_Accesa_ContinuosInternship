import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { Portal } from './components/Portal/Portal';

export interface IPortalRootProps { }

export interface IPortalRootState { }

export class PortalRoot extends React.Component<IPortalRootProps, IPortalRootState> {

    constructor(props: IPortalRootProps) {
        super(props);
    }

    render() {
        return <Portal />;
    }
}

ReactDOM.render(
    <PortalRoot />,
    document.getElementById('portal')
);