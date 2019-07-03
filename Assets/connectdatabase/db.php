<?php
class db {
	private $host= "localhost";
	private $username= "s58660001";
	private $password= "kasinbadee314";
	private $dbname= "s58660001";
	public $link;
	public $result;

	function connect() {
		if($this->link = mysqli_connect($this->host,$this->username,$this->password,$this->dbname)) {
			return ($this->link);
		}else {
			echo "Could not connect to the database!!!";
			return false;
		}
	}


	function query($sql) {
		mysqli_query($this->link,"set names utf8");
		if($this->result = mysqli_query($this->link,$sql)){
			return ($this->result);
		}else{
			return false;
		}
	}


	function close(){
		mysqli_close($this->link);
	}
}
?>
