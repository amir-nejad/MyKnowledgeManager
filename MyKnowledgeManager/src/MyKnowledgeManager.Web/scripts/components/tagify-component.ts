//import * as Tagify from "@yaireo/tagify";
import { BaseTagData, TagifySettings } from "@yaireo/tagify";

declare class Tagify {
    whitelist: string[] | BaseTagData[]
    constructor(inputElement: HTMLInputElement | HTMLTextAreaElement, settings?: TagifySettings);
}

export class TagifyComponent {
    constructor() {

    }

    getTagify(inputElem: HTMLInputElement | HTMLTextAreaElement, whiteList?: string[] | BaseTagData[], customSettings?: TagifySettings) {
        var tagifyObject = new Tagify(inputElem, {
            whitelist: whiteList,
            duplicates: false,
            autoComplete: {
                enabled: true,
                rightKey: true
            },
            trim: true
        });

        if (customSettings) {
            tagifyObject = new Tagify(inputElem, customSettings);
            tagifyObject.whitelist = whiteList;
        }
    }
}


