import * as React from 'react';
import './Common.css';

export interface IAddButtonProps {
    onClick(event: any): void;
}

export class AddButton extends React.Component<IAddButtonProps, any> {

    constructor(props: IAddButtonProps) {
        super(props);
    }

    render() {
        return (
            <div className='artB-DivAddButton'>
                <i className='material-icons artB-AddButton' onClick={this.props.onClick}>add </i>
            </div>
        );
    }
}