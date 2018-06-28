import * as React from 'react';
import { WithContext as ReactTags } from 'react-tag-input';

import './Common.css';

const KeyCodes = {
    comma: 188,
    enter: 13,
    tab: 9,
};

const delimiters = [KeyCodes.comma, KeyCodes.enter, KeyCodes.tab];

export interface ITag {
    id: string;
    name: string;
}

export interface IInputState {
    tags: ITag[];
    suggestions: any;
}

export interface ITagsInputProps {
    id: string;
    name: string;
    tags: ITag[];
    suggestions: ITag[];
    onTagsChanged(tags: ITag[]): void;
}

export class TagsInput extends React.Component<ITagsInputProps, IInputState> {

    constructor(props: ITagsInputProps) {
        super(props);
        this.state = {
            tags: props.tags,
            suggestions: props.suggestions.map((suggestion: ITag) => {
                return {
                    id: suggestion.id.toString(),
                    text: suggestion.name
                }
            }),
        };
    }

    private handleDelete = (i: any) => {
        let tags = this.state.tags;
        tags.splice(i, 1);
        this.setState({ tags: tags });
        this.props.onTagsChanged(this.state.tags);
    }

    private handleAddition = (tag: any) => {
        let tags = this.state.tags;
        let duplicateTagIndex = tags.findIndex((existingTag: ITag) => {
            return existingTag.name === tag.text;
        });

        if (duplicateTagIndex === -1) {
            tags.push({
                id: `temp_${(tags.length + 1)}`,
                name: tag.text
            });
            this.setState({ tags: tags });
        }
        this.props.onTagsChanged(this.state.tags);        
    }

    render() {
        return (
            <div className='artB-InputForm'>
                <span className='artB-Text'>{this.props.name}: </span>
                <ReactTags id={this.props.id}
                    tags={this.state.tags.map(t => ({ text: t.name, id: t.id }))}
                    delimiters={delimiters}
                    suggestions={this.state.suggestions}
                    handleDelete={this.handleDelete}
                    handleAddition={this.handleAddition}
                />
            </div>
        );
    }
}