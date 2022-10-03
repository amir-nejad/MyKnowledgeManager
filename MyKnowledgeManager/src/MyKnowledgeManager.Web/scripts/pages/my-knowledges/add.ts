

let inputElement: HTMLInputElement = document.getElementById("Tags")! as HTMLInputElement;

var tagifyObject = new Tagify(inputElement, {
    whitelist: ["Test", "Amirhossein"],
    duplicates: false,
    autoComplete: {
        enabled: true,
        rightKey: true
    },
    trim: true
});