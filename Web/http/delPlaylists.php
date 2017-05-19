<?php
require_once("php/functions.php");
session_start();

CheckConnexion();
CheckAdmin();
//Check the informations
if(isset($_POST['playlistToDel'])){
  //Go through the array of id and deletes one by one
  foreach ($_POST['playlistToDel'] as $idToDel) {
    $sql = "DELETE FROM playlists WHERE idPlaylist = :id";
    $query = $db->prepare($sql);
    $query->execute(array(
      'id' => $idToDel
    ));
  }
  header("Location: manageUsers.php");
}
