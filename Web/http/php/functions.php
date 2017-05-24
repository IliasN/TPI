<?php
/*
Author : N'hairi Ilias
Version : 1.0
Date : 23.05.2017
*/
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

function CheckAdmin(){
  if ($_SESSION['privilegeUser'] == 0) {
    header("Location: user.php");
  }
}

function CreateSelectArtists(){
  $db = Database();
  $result = '<select name="idArtist" class="form-control" id="exampleSelect1" name="">';
  $sql = "SELECT * FROM artists";
  $query = $db->prepare($sql);
  $query->execute();
  $artists = $query->fetchall();
  foreach ($artists as $artist) {
    $result .= '<option value="'.$artist['idArtist'].'">'.$artist['nameArtist'].'</option>';
  }
  $result .= "</select>";
  echo $result;
}

function CreateSelectTypes(){
  $db = Database();
  $result = '<select name="idType" class="form-control" id="exampleSelect1" name="">';
  $sql = "SELECT * FROM types";
  $query = $db->prepare($sql);
  $query->execute();
  $artists = $query->fetchall();
  foreach ($artists as $artist) {
    $result .= '<option value="'.$artist['idType'].'">'.$artist['labelType'].'</option>';
  }
  $result .= "</select>";
  echo $result;
}
