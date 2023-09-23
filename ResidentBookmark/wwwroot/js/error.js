var body = document.body;
var backgroundUrl = "url('../images/background/error.jpg')"

pageBackground();

function pageBackground() { 

    body.style.backgroundAttachment = "fixed";
    body.style.backgroundColor = "#fff";
    body.style.backgroundImage = backgroundUrl;
    body.style.backgroundPosition = "center";
    body.style.backgroundRepeat = "no-repeat";
    body.style.backgroundSize = "cover";
}