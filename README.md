# eventee

## Feature expectations:
- The ability to create events
    - The ability to specify a date, time, and location of the event to take place
    - The event should have a status "Pending event", "Arranged event", "Cancelled Event"
    - The ability to specify the minimum amount of required attendees to RSVP "I will attend" before an event is added in Discord
- The ability to add required attendees
- The ability to add optional attendees
- The ability for attendees to RSVP
    - Options to include "I will attend", "I may be able to attend", "I cannot attend"
- When an event reaches the minimum level of acceptance RSVP's, an Event in Discord should be created
- The ability to list events, based on the server the request originated from

## RC1 Features:
- The ability to create events
- The ability to specify a date, time, and location of the event to take place
- The ability to add required attendees
- The ability for attendees to RSVP
    - Accept / Decline
- The ability to list events, based on the server the request originated from

## RC2 Features:
- The event should have a status "Pending event", "Arranged event", "Cancelled Event"
- The ability to specify the minimum amount of required attendees to RSVP "I will attend" before an event is added in Discord
- The ability to add optional attendees
- Options to include "I will attend", "I may be able to attend", "I cannot attend"
- When an event reaches the minimum level of acceptance RSVP's, an Event in Discord should be created

## RC3 Features:
- Private events

## RC4 Features:
- External integration with calendar apps
    - Potentially Calendly

### RFC:
- Use threads in Discord for managing events so an event identifier is not required
- Have `/eventee invites list` use buttons to accept/decline invites
    - Send 1 message per event invite with accept/maybe/decline buttons
    - Send 1 message with all event buttons wit the event name in the button
- If an event is created when the server has Discord events disabled, which are later enabled before the event starts, should Eventee create a Discord event for it?

## Available commands:

## Commands to be implemented:
- /eventee admin role add {@role}
- /eventee admin role remove {@role}
- /eventee admin role allow {create/manage/admin} {@role}
- /eventee admin role deny {create/manage/admin} {@role}
- /eventee admin reminder {#channel}
- /eventee admin reminder disable
- /eventee admin events enable
- /eventee admin events disable
- /eventee create {name} {location} {@required} {private (optional, default false)}
- /eventee edit {eventID} minimum {min. required accepts}
- /eventee edit {eventID} invite {required/optional} {@user}
- /eventee edit {eventID} remove {@user}
- /eventee edit {eventID} location {location}
- /eventee edit {eventID} description {description}
- /eventee edit {eventID} title {title}
- /eventee edit {eventID} start {start}
- /eventee edit {eventID} end {end}
- /eventee edit {eventID} cancel
- /eventee edit {eventID} confirm
- /eventee edit {eventID} reminder add {date} {time} {type (optional, default channel)}
- /eventee edit {eventID} reminder remove all
- /eventee edit {eventID} reminder remove {date} {time} {type (optional, default channel)}
- /eventee invites list
- /eventee invites accept {eventID}
- /eventee invites maybe {eventID}
- /eventee invites decline {eventID}
- /eventee event {eventID}
- /eventee event {eventID} join