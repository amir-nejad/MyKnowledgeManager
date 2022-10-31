import { myKnowledgeTags } from "../../utils/constants.js";
import { TagifyComponent } from "../../components/tagify-component.js";
//declare class TagifyComponent {
//    constructor();
//    getTagify(inputElem, whitelist?, customSettings?);
//}
//declare var tagifyComponent: TagifyComponent;
// Getting input element for tagify
let inputElem = document.getElementById("TagsJson");
// Getting previous tags from localStorage if exist.
let localStorageTags = localStorage.getItem(myKnowledgeTags);
let previousTags = null;
if (localStorageTags) {
    previousTags = localStorageTags.split(",");
}
let tagifyComponent = new TagifyComponent();
tagifyComponent.getTagify(inputElem, previousTags, null);
//# sourceMappingURL=add.js.map