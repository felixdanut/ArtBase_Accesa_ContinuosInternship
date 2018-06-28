import * as React from 'react';
import * as classnames from 'classnames';
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

export class Tab extends React.Component<ITabProps> {
    public render() {
        const classNames = classnames('artB-Tab', {
            'artB-Tab-active': this.props.showAsActive
        },);

        const classNamesPortal = classnames('artB-Tab-Portal', {
            'artB-Tab-Portal-active': this.props.showAsActive
        },);

        const classNamesIcon = classnames('artB-Icon', {
            'artB-Icon-active': this.props.showAsActive
        });

        return (
            <div>
                <div onClick={this.props.tabInfo.onClick} className={this.props.tabInfo.icon != '' ? classNamesPortal : classNames}>
                    <img className={classNamesIcon} src={this.props.tabInfo.icon} alt="" height="22" width="22"/>
                    {this.props.tabInfo.name}
                </div>
            </div>
        );
    }
}