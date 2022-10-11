export class TagifyComponent {
    constructor() {
    }
    getTagify(inputElem, whiteList, customSettings) {
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
//# sourceMappingURL=tagify-component.js.map