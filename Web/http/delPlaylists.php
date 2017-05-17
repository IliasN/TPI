<?php
require_once("php/functions.php");
session_start();
if(isset($_POST['playlistToDel'])){
  foreach ($_POST['playlistToDel'] as $idToDel) {
    $sql = "DELETE FROM playlists WHERE idPlaylist = :id";
    $query = $db->prepare($sql);
    $query->execute(array(
      'id' => $idToDel
    ));
  }
  header("Location: manageUsers.php");
}
