import * as React from 'react';
import './Common.css';
import * as classnames from 'classnames';

let className: string, message: string;

export interface NotificationProps {
    message: string;
    className: string;
    title: string;
}

export class Notification extends React.Component<NotificationProps, any> {

    constructor(props: NotificationProps) {
        super(props);
    }

    render() {
        return (
            <div className='artB-Notification'>
                <span className={this.props.className}><b>{this.props.title}</b> {this.props.message}</span>
            </div>
        );
    }
}