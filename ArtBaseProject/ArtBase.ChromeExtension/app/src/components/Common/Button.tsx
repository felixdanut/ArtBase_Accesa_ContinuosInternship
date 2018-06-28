import * as React from 'react';
import './Common.css';

export interface IButtonProps {
    id: () => string;
    name: string;
    onClick(event: any): void;
}

export class Button extends React.Component<IButtonProps, any> {

    constructor(props: IButtonProps) {
        super(props);
    }

    render() {
        return (
            <div>
                <button className='artB-Button artB-Ripple' onClick={this.props.onClick} >{this.props.name}</button>
            </div>
        );
    }
}