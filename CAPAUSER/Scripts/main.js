
const navItemTouch = document.getElementById("ul_container")
const itemTouch = navItemTouch.getElementsByClassName("li_items")

for (let i = 0; i < itemTouch.length; i++) {

    itemTouch[i].addEventListener("click", function () {
        
        for (let a = 0; a < itemTouch.length; a++) {
           
         itemTouch[a].classList.remove("active");
        }
       this.classList.add("active")
    });

}