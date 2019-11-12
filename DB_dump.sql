-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema sysnozawa
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema sysnozawa
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `sysnozawa` DEFAULT CHARACTER SET utf8 ;
USE `sysnozawa` ;

-- -----------------------------------------------------
-- Table `sysnozawa`.`staff`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sysnozawa`.`staff` (
  `id` INT(11) NOT NULL,
  `name` VARCHAR(20) NULL DEFAULT NULL,
  `insertdatetime` TIMESTAMP NULL DEFAULT NULL,
  `updatedatetime` TIMESTAMP NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `name_unique` (`name` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `sysnozawa`.`client`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sysnozawa`.`client` (
  `id` INT(11) NOT NULL,
  `code` VARCHAR(10) NULL DEFAULT NULL,
  `name` VARCHAR(50) NULL DEFAULT NULL,
  `insertdatetime` TIMESTAMP NULL DEFAULT NULL,
  `updatedatetime` TIMESTAMP NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `code_unique` (`code` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `sysnozawa`.`anken`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sysnozawa`.`anken` (
  `id` INT(11) NOT NULL,
  `code1` VARCHAR(10) NOT NULL,
  `code2` VARCHAR(10) NOT NULL,
  `code3` VARCHAR(10) NOT NULL,
  `name` VARCHAR(50) NULL DEFAULT NULL,
  `clientid` INT(11) NULL DEFAULT NULL,
  `staffid` INT(11) NULL DEFAULT NULL,
  `salesyearmonth` DATE NULL DEFAULT NULL,
  `status` INT(11) NULL DEFAULT NULL,
  `salesamount` DECIMAL(10,0) NULL DEFAULT NULL,
  `insertdatetime` TIMESTAMP NULL DEFAULT NULL,
  `updatedatetime` TIMESTAMP NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `code_unique` (`code1` ASC, `code2` ASC, `code3` ASC) VISIBLE,
  INDEX `staffid` (`staffid` ASC) VISIBLE,
  INDEX `clientid` (`clientid` ASC) VISIBLE,
  CONSTRAINT `anken_ibfk_1`
    FOREIGN KEY (`staffid`)
    REFERENCES `sysnozawa`.`staff` (`id`),
  CONSTRAINT `anken_ibfk_2`
    FOREIGN KEY (`clientid`)
    REFERENCES `sysnozawa`.`client` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `sysnozawa`.`calendar`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sysnozawa`.`calendar` (
  `id` INT(11) NOT NULL,
  `day` DATE NULL DEFAULT NULL,
  `holidayflg` INT(11) NULL DEFAULT NULL,
  `insertdatetime` TIMESTAMP NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `day_unique` (`day` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `sysnozawa`.`shop`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sysnozawa`.`shop` (
  `id` INT(11) NOT NULL,
  `code` VARCHAR(10) NULL DEFAULT NULL,
  `name` VARCHAR(50) NULL DEFAULT NULL,
  `insertdatetime` TIMESTAMP NULL DEFAULT NULL,
  `updatedatetime` TIMESTAMP NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `code` (`code` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
