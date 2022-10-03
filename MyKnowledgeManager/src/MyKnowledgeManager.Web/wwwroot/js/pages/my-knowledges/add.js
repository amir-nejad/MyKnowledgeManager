let inputElement = document.getElementById("Tags");
var tagifyObject = new Tagify(inputElement, {
    whitelist: ["Test", "Amirhossein"],
    duplicates: false,
    autoComplete: {
        enabled: true,
        rightKey: true
    },
    trim: true
});
//# sourceMappingURL=add.js.map