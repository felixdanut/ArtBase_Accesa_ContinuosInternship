import * as React from 'react';
import './Tabs.css';
import { ITabInfo, Tab } from './Tab';

export interface ITabbedNavigationState {
    activeTab: ITabInfo;
}

export interface ITabbedNavigationProps {
    tabs: ITabInfo[];
}

export class TabbedNavigation extends React.Component<ITabbedNavigationProps, ITabbedNavigationState> {
    
    constructor(props: ITabbedNavigationProps) {
        super(props);

        this.state = {
            activeTab: props.tabs.length ? props.tabs[0] : null
        };
    }

    private setActiveTab(tab: ITabInfo) {
        this.setState({ activeTab: tab });
    }

    public render() {
        return (
            <div className={this.state.activeTab.icon != '' ? 'artB-TabbedNavigation-Portal' : 'artB-TabbedNavigation'}>
                {
                    this.props.tabs.map((tab, index) => (
                        <div key={index} className={this.state.activeTab.icon != '' ? 'artB-TabContainer-Portal' : 'artB-TabContainer'} onClick={() => this.setActiveTab(tab)}>
                            <Tab tabInfo={tab} key={index} showAsActive={tab === this.state.activeTab} />
                        </div>))
                }
            </div>
        );
    }
}