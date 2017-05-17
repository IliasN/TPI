<?php
$db = Database();
function Database()
{
  $user = "root";
  $pass = "";
  return new PDO('mysql:host=localhost;dbname=tpi', $user, $pass);
}


function Debug($data){
  echo "<pre>";
  print_r($data);
  echo "</pre>";
}

function CheckConnexion(){
  if (!isset($_SESSION['idUser'])) {
    header("Location: index.php");
  }
}
