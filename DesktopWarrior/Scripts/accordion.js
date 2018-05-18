
var acc = document.getElementsByClassName("accordion-btn");
var i;

for (i = 0; i < acc.length; i++) {
    acc[i].addEventListener("click", function () {
        this.classList.toggle("active");
        if (this.classList.contains("active")) {
            $(event.target).html("Close  ▲");
        } else {
            $(event.target).html("Open   ▼");
         }
        var panel = document.getElementsByClassName('accordion-content')[0];
        if (panel.style.maxHeight) {
            panel.style.maxHeight = null;
        } else {
            panel.style.maxHeight = panel.scrollHeight + "px";
        } 
    });
}