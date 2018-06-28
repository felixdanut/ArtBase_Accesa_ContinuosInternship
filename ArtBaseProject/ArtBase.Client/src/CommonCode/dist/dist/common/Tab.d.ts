import * as React from 'react';
import './Tabs.css';
export interface ITabInfo {
    name: string;
    icon: string;
    onClick(): void;
}
export interface ITabProps {
    tabInfo: ITabInfo;
    showAsActive: boolean;
}
export declare class Tab extends React.Component<ITabProps> {
    render(): JSX.Element;
}
