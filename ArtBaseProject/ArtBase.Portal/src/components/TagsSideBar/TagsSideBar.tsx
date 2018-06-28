import * as React from 'react';
import './TagsSideBar.css';

export interface ITag {
   id: number;
   name: string; 
}

export interface ITagsSideBarState { 
    value: string;
}

export interface ITagsSideBarProps {
    onSelectedValueChanged(tag: ITag): void;
    tags: ITag[];
}

export class TagsSideBar extends React.Component<ITagsSideBarProps, ITagsSideBarState> {

    constructor(props: ITagsSideBarProps) {
        super(props);
        this.state = { value: ' ' };
    }

    private handleChange = (event: any) => {
        this.props.onSelectedValueChanged(this.props.tags.find((tag: ITag) => tag.name == event.target.text));
        this.setState ({
            value: event.target.text
        });
    }

    render() {
        return (
            <div className='artB-TagsSideBar'>
                <span className='artB-Title'>Tags: </span>
                <ul>
                    {
                        this.props.tags.map((tag) => (
                          <li key={tag.id} className={this.state.value === tag.name ? 'artB-ActiveTag' : '' }><a href="#" onClick={this.handleChange}>{tag.name}</a></li>  
                        ))
                    }
                </ul>
            </div>
        );
    }
}