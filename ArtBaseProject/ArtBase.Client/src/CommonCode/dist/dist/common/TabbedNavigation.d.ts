import * as React from 'react';
import './Tabs.css';
import { ITabInfo } from './Tab';
export interface ITabbedNavigationState {
    activeTab: ITabInfo;
}
export interface ITabbedNavigationProps {
    tabs: ITabInfo[];
}
export declare class TabbedNavigation extends React.Component<ITabbedNavigationProps, ITabbedNavigationState> {
    constructor(props: ITabbedNavigationProps);
    private setActiveTab;
    render(): JSX.Element;
}
