DROP DATABASE IF EXISTS `Mariposa`;
CREATE DATABASE IF NOT EXISTS `Mariposa` DEFAULT CHARACTER SET latin1;
USE `Mariposa`;

-- -----------------------------------------------------
-- Table `Mariposa`.`butterflies`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Mariposa`.`butterflies` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `LatinName` VARCHAR(50) NULL DEFAULT NULL,
  `PolishName` VARCHAR(50) NULL DEFAULT NULL,
  `Description` MEDIUMTEXT NULL DEFAULT NULL,
  PRIMARY KEY (`Id`)
  ) 
DEFAULT CHARACTER SET = utf8mb4;


