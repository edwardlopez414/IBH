function changewindows() {
    var x = document.getElementById("datauser");
    var xupdate = document.getElementById("dataupdate");
    var xdelete = document.getElementById("datadelete");
        x.style.display = "";
        xupdate.style.display = "none";
        xdelete.style.display = "none";
    
}
function changedelete() {
    var x = document.getElementById("datauser");
    var xupdate = document.getElementById("dataupdate");
    var xdelete = document.getElementById("datadelete");
    
        x.style.display = "none";
        xupdate.style.display = "none";
        xdelete.style.display = "";
       

}
function changeupdate() {
    var x = document.getElementById("datauser");
    var xupdate = document.getElementById("dataupdate");
    var xdelete = document.getElementById("datadelete");
        x.style.display = "none";
        xupdate.style.display = "";
        xdelete.styles.display = "none";
   
}