use WordLists
--319451 rows in the initial table.

--Delete all the words which are not from LLVV or MLVV
select * from WordListLV2 where Dictionaries not like '%LLVV%' and Dictionaries not like '%MLVV%'
delete from WordListLV2 where Dictionaries not like '%LLVV%' and Dictionaries not like '%MLVV%'

--Delete all the non-nouns
select * from WordListLV2 where [Part of speech] <> 'NOUN'
delete from WordListLV2 where [Part of speech] <> 'NOUN'

--Check for nulls in the Word column
select * from WordListLV2 where Word is null

--Delete all the words which contain less than 4 letters
select * from WordListLV2 where Word like '_' or Word like '__' or Word like '___'
delete from WordListLV2 where Word like '_' or Word like '__' or Word like '___'

--Add an ID column; numbers are added automatically
alter table WordListLV2
add WordID int not null identity primary key

--Find and display duplicate rows with number of repititions
select Word, count(*) as Repititions from WordListLV2
group by Word having count(*) > 1

--Find and display IDs of the duplicate values except for max ID, remove these rows
select * from WordListLV2 where WordID not in(
	select max(WordID) from WordListLV_2 group by Word
)
delete from WordListLV2 where WordID not in(
	select max(WordID) from WordListLV_2 group by Word
)

select * from WordListLV2 where Word like '%u'
delete from WordListLV2 where Word like '%u'

select * from WordListLV2 where Word like '%vakara'
delete from WordListLV2 where Word like '%vakara'

select * from WordListLV2 where Word like '%r_ta'
delete from WordListLV2 where WordID in (4170, 9334, 14880, 14904, 16047, 16595, 19483, 20649)

select * from WordListLV2 where Word like '%dienas'
delete from WordListLV2 where WordID in (3534, 19496, 25886, 8841)

select Word from WordListLV2 order by Word asc

--33723 rows in cleaned table.