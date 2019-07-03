<?php
class User {
	public $user_id;
	public $email;
	public $money;
	public $lvl;

	function __construct($u,$e,$m,$l)
	{
		$this->user_id = $u;
		$this->email = $e;
		$this->money = $m;
		$this->lvl = $l;
	}
}

header ( 'Content-type: application/json' );
include "db.php";
$response = array();
$ok = true;
if(!isset($_REQUEST['username'])){
	$ok=false;
	$response['status'] = 'Please Set User Name before Submit';
}

else if(!isset($_REQUEST['password'])){
	$ok = false;
	$response['status'] = 'Please Set password';

} else{
	$name = $_REQUEST['username'];
	$password = $_REQUEST['password'];
}

if($ok){
	$db = new db();
	$db -> connect();
	$sql	="SELECT * FROM Pet_User WHERE username='$name' AND password='$password'";
	$result = $db->query($sql);
	if(mysqli_num_rows($result)>0){
		$row = mysqli_fetch_array($result);

		$u = new User($row[0],$row[3], $row[4], $row[5]);
		$response['status'] = 1;
		$response['info'] = $u;
	}else{
		$response['status'] = 0;
	}
}

echo json_encode($response);
?>
