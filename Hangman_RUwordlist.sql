use WordLists

--51300 rows in the initial table.

select * from WordListRU where Word like '_' or Word like '__' or Word like '___'
delete from WordListRU where Word like '_' or Word like '__' or Word like '___'

--Find and display duplicate rows with the number of repititions
select Word, count(*) as CNT from WordListRU
group by Word having count(*) > 1

--Add an ID column; numbers are added automatically
alter table WordListRU
add WordID int not null identity primary key

select Word from WordListRU

--50774 rows in cleaned table.
