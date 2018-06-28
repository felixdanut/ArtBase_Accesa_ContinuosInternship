import * as React from 'react';
import './CategorySideBar.css';

export interface IOption {
    id: number;
    name: string;
}

export interface ICategorySideBarState { 
    value: string;
}

export interface ICategorySideBarProps {
    onSelectedValueChanged(option: IOption): void;
    options: IOption[];
}

export class CategorySideBar extends React.Component<ICategorySideBarProps, ICategorySideBarState> {

    constructor(props: ICategorySideBarProps) {
        super(props);
        this.state = { value: ' ' };
    }

    private handleChange = (event: any) => {
        this.props.onSelectedValueChanged(this.props.options.find((option: IOption) => option.name == event.target.text));
        this.setState ({
            value: event.target.text
        });
    }

    render() {
        return (
            <div className='artB-CategorySideBar'>
                <span className='artB-Title'>Category: </span>
                <ul>
                    {
                        this.props.options.map((option) => (
                          <li key={option.id}><a href="#" className={this.state.value === option.name ? 'artB-Active' : '' } onClick={this.handleChange}>{option.name}</a></li>  
                        ))
                    }
                </ul>
            </div>
        );
    }
}