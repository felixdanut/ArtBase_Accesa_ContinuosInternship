import * as React from 'react';
import './Common.css';

export interface IOption {
    id: number;
    name: string;
}

export interface IDropDownState {
    value: string;
}

export interface IDropDownProps {
    name: string;
    category: IOption;
    onSelectValueChanged(option: IOption): void;
    options: IOption[];
    unselectedPlaceHolder: string;
}

export class DropDown extends React.Component<IDropDownProps, IDropDownState> {

    constructor(props: IDropDownProps) {
        super(props);
        this.state = { value: '' };
    }

    private handleChange = (event: any) => {
        this.props.onSelectValueChanged(this.props.options.find((option: IOption) => option.id == event.target.value));
        this.setState({
            value: event.target.value
        });
    }

    render() {
        return (
            <div className='artB-DropDown'>
                <span className='artB-Text'>{this.props.name}: </span>
                <select value={(this.props.category !== null) ? this.props.category.id : this.state.value} onChange={this.handleChange} className='artB-DropDownSelect' >
                    <option value='' disabled> {this.props.unselectedPlaceHolder} </option>
                    {
                        this.props.options.map((option) => (
                            <option key={option.id} value={option.id}>{option.name}</option>
                        ))
                    }
                </select>
            </div>
        );
    }
}