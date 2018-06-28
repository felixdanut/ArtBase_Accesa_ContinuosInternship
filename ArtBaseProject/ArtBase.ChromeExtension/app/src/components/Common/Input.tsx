import * as React from 'react';
import './Common.css';

export interface IInputState {
    value: string;
}

export interface IInputProps {
    id: string;
    name: string;
    inputText: string;
    onInputValueChanged(value: string): void;
}

export class Input extends React.Component<IInputProps, IInputState> {

    constructor(props: IInputProps) {
        super(props);
        this.state = {
            value: props.inputText,
        };
    }

    public componentWillReceiveProps(props: IInputProps) {
        if (this.state.value !== props.inputText) {
            this.setState({ value: props.inputText });
        }
    }

    private handleChange = (event: any) => {
        this.props.onInputValueChanged(event.target.value);
        this.setState({ value: event.target.value });
    }

    render() {
        return ( 
            <div className='artB-InputForm'>
                <span className='artB-Text'>{this.props.name}: </span>
                <input id={this.props.id} type='text' name={this.props.name} value={this.state.value} className='artB-Input' onChange={this.handleChange} />
            </div>
        );
    }
}