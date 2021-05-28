// Change logo brightness on mouse over and revert to normal on mouse out.

var logo = document.getElementById("logo");

logo.onmouseover = function() {mouseOverLogo()};
logo.onmouseout = function() {mouseOutLogo()};

function mouseOverLogo() {
    logo.src="../images/logo/rslogolight.png";
}

function mouseOutLogo() {
    logo.src="../images/logo/rslogo.png";
}

var logofooter = document.getElementById("logofooter");

logofooter.onmouseover = function() {mouseOverLogoFooter()};
logofooter.onmouseout = function() {mouseOutLogoFooter()};

function mouseOverLogoFooter() {
    logofooter.src="../images/logo/rslogofooterlight.png";
}

function mouseOutLogoFooter() {
    logofooter.src="../images/logo/rslogofooter.png";
}
