import * as React from 'react';
import './Common.css';

export interface ISearchBarProps {
    onSearch: any;
    inputText: string;
}

export interface ISearchBarState {
    value: string;
}

export class SearchBar extends React.Component<ISearchBarProps, ISearchBarState> {

    constructor(props: ISearchBarProps) {
        super(props);
        this.state = {
            value: props.inputText,
        };
        this.search = this.debounce(this.search, 500);
    }

    private debounce(fn: Function, delay: number) {
        let timer: number;
        return function () {
            const context = this, args = arguments;
            window.clearTimeout(timer);
            timer = window.setTimeout(function () {
                fn.apply(context, args);
            }, delay);
        };
    }

    private onChange = (searchInputValue: string) => {
        this.setState({
            value: searchInputValue,
        });
        this.search(searchInputValue);
    };

    private search = (searchInputValue: string) => {
        this.props.onSearch(searchInputValue);
    }

    render() {
        return (
            <div className='artB-SearchBar'>
                <input autoFocus={true} type="text" id="searchInput" placeholder="Search..." name="search" value={this.state.value} onChange={e => this.onChange(e.target.value)} />
                <button><i className="fa fa-search"></i></button>
            </div>
        );
    }
}