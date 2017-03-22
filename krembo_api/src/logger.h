/*************************************************************************
 *
 *
 * #include "logger.h"
 * ...
 * LOG_LINE("some text");
 *************************************************************************/
#ifndef LOGGER_H
#define LOGGER_H

//comment following line to disable debug printing:
#define DEBUG_MODE

#ifdef DEBUG_MODE
#define LOG_LINE(str) do { Serial.println(str);} while( false )
#define LOG(str) do { Serial.print(str);} while( false )
#else
#define LOG_LINE(str) do {} while( false )
#define LOG(str) do {} while( false )
#endif

#endif //DEBUGER_H
