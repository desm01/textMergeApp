# textMergeApp
Here's an application I made that will help clean up data-sets. 

I used the application for OpenAis GPT-2, but there's infinite other use cases that you can adopt it to

When downloading and using GPT-2, I struggled to build my own data-sets as most of the data I downloaded was stored in hundreds 
(Sometimes thousands) of diffrent text files. So I put together this application that will let people combine all the textfiles together
into a singular file that can be used to fine-tune the nueral network.

The application stores each file in the single output file, and seperates the entries with <|startoftext|> and <|lastoftext|> 
I have done this becuase I found that when finetuneing GPT-2 you will get better results whenever you specify where new articles begin

If you're intrested in using this to gain better results on GPT-2, I recomend this article: 

https://towardsdatascience.com/how-to-fine-tune-gpt-2-so-you-can-generate-long-form-creative-writing-7a5ae1314a61

To use the application, either run the solution in visual studio (Open the textMergeApp.sln file in the main repo) or alternativley you can navigate to  bin/debug/textMergeApp.exe
