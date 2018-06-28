import * as React from 'react';
import './SaveBookmarkForm.css';
import { Input } from '../Common/Input';
import { DropDown, IOption } from '../Common/DropDown';
import { TagsInput, ITag } from '../Common/TagsInput';
import { Button } from '../Common/Button';
import { LoadingSpinner, Chrome, DAL } from 'artbase-common';
import { Notification } from '../Common/Notification';

export interface IBookmark {
    id: number;
    title: string;
    url: string;
    category: IOption;
    tags: ITag[];
    user: any;
}

export interface ISaveBookmarkFormState {
    bookmark: IBookmark;
    categories: IOption[];
    tabInfoLoaded: boolean;
    categoriesLoaded: boolean;
    tagsLoaded: boolean;
    hasError: boolean;
    errorMessage: string;
    isSuccessful: boolean;
    succesMessage: string;
    tagSuggestions: ITag[];
}

export interface ISaveBookmarkFormProps { }

export class SaveBookmarkForm extends React.Component<ISaveBookmarkFormProps, ISaveBookmarkFormState> {

    constructor(props: ISaveBookmarkFormProps) {
        super(props);
        this.state = {
            bookmark: { id: null, title: '', url: '', category: null, tags: [], user: {} },
            categories: [],
            tabInfoLoaded: false,
            categoriesLoaded: false,
            tagsLoaded: false,
            hasError: false,
            errorMessage: '',
            isSuccessful: false,
            succesMessage: '',
            tagSuggestions: [],
        };
    }

    componentDidMount() {

        Chrome.getTabInfo().then((tabInfo) => {
            let bookmark = {
                url: tabInfo.url
            }
            DAL.checkBookmarkExists(bookmark).then((bookmark: any) => {
                if (bookmark.data) {
                    this.setState({
                        bookmark: bookmark.data,
                        tabInfoLoaded: true
                    })
                }
                else {
                    this.setState(prevState => ({
                        bookmark: {
                            ...prevState.bookmark,
                            title: tabInfo.title,
                            url: tabInfo.url
                        },
                        tabInfoLoaded: true
                    }));
                }
            });
        });

        DAL.getCategories().then((res: any) => {
            this.setState({ categories: res.data, categoriesLoaded: true });
        });

        DAL.getTags().then((res: any) => {
            this.setState({ tagSuggestions: res.data, tagsLoaded: true });
        })
    }

    private handleTitleChange = (title: string) => {
        const bookmark = this.state.bookmark;
        bookmark.title = title;
        this.setState({ bookmark: bookmark });
    }

    private handleUrlChange = (url: string) => {
        const bookmark = this.state.bookmark;
        bookmark.url = url;
        this.setState({ bookmark: bookmark });
    }

    private handleCategorySelect = (category: IOption) => {
        const bookmark = this.state.bookmark;
        bookmark.category = category;
        this.setState({ bookmark: bookmark });
    }

    private handleTagsChanged = (tags: ITag[]) => {
        const bookmark = this.state.bookmark;
        bookmark.tags = tags;
        this.setState({ bookmark: bookmark });
    }

    private handleSubmit = (event: any) => {
        let errorMessage = '';
        if (!this.state.bookmark.title) {
            errorMessage += '\n The title is empty. ';
        }

        if (!this.state.bookmark.url || !this.validateURL(this.state.bookmark.url)) {
            errorMessage += '\n The URL is not valid. ';
        }

        if (!this.state.bookmark.category) {
            errorMessage += '\n The category is not selected. ';
        }

        if (this.state.bookmark.tags.length < 1) {
            errorMessage += '\n At least one tag is required. ';
        }

        if (!errorMessage) {
            let currentBookmark = this.state.bookmark;
            currentBookmark.tags = this.sanitizeTags(this.state.bookmark.tags);

            const promise = currentBookmark.id ? DAL.updateBookmark(JSON.stringify(currentBookmark)) : DAL.addBookmark(JSON.stringify(currentBookmark));

            promise.then((bookmark: any) => {
                if (bookmark.data) {
                    this.setState({
                        bookmark: bookmark.data
                    })
                }
                this.setTimeoutSuccessfull(currentBookmark.id ? '\n Bookmark updated succesfully.' : '\n Bookmark saved successfully.');
            });

            this.setState({ hasError: false });
        }
        else {
            this.setState({ hasError: true, isSuccessful: false, errorMessage: errorMessage });
        }
    }

    private setTimeoutSuccessfull = (succesMessage: string) => {
        this.setState({ isSuccessful: true, succesMessage: succesMessage }, () => {
            setTimeout(() => { this.setState({ isSuccessful: false }) }, 2000);
        });
    }

    private validateURL(url: string) {
        var urlregex = /^(https?|ftp|http):\/\/([a-zA-Z0-9.-]+(:[a-zA-Z0-9.&%$-]+)*@)*((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[1-9][0-9]?)(\.(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[1-9]?[0-9])){3}|([a-zA-Z0-9-]+\.)*[a-zA-Z0-9-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{2}))(:[0-9]+)*(\/($|[a-zA-Z0-9.,?'\\+&%$#=~_-]+))*$/;
        return urlregex.test(url);
    }

    private sanitizeTags(tags: ITag[]) {
        tags.forEach(tag => {
            if (tag.id.toString().startsWith('temp')) {
                tag.id = '';
            }
        });
        return tags;
    }

    render() {
        if (this.state.tabInfoLoaded && this.state.categoriesLoaded && this.state.tagsLoaded) {
            let submitButtonText = 'Save';
            if (this.state.bookmark.id) {
                submitButtonText = 'Update';
            }

            return (
                <div className='artB-SaveBookmarkForm'>
                    <Input id='name' name='Title' inputText={this.state.bookmark.title} onInputValueChanged={this.handleTitleChange} />
                    <Input id='url' name='URL' inputText={this.state.bookmark.url} onInputValueChanged={this.handleUrlChange} />
                    <DropDown name='Category' category={this.state.bookmark.category} onSelectValueChanged={this.handleCategorySelect} options={this.state.categories} unselectedPlaceHolder=' -- Select a category -- ' />
                    <TagsInput id='tags' name='Tags' tags={this.state.bookmark.tags} suggestions={this.state.tagSuggestions} onTagsChanged={this.handleTagsChanged} />
                    {this.state.hasError && <Notification className='artB-SpanError' title='Oops, something happened!' message={this.state.errorMessage} />}
                    {this.state.isSuccessful && <Notification className='artB-SpanSuccess' title='Ooh, yeah!' message={this.state.succesMessage} />}
                    <div className='artB-SaveButton'>
                        <Button id={submitButtonText.toLowerCase} name={submitButtonText} onClick={this.handleSubmit} />
                    </div>
                </div>
            )
        }

        return <LoadingSpinner />;
    }
}