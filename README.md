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
- /evadmin role add {@role}
- /evadmin role remove {@role}
- /evadmin role allow {create/manage/admin} {@role}
- /evadmin role deny {create/manage/admin} {@role}
- /evadmin reminder {#channel}
- /evadmin reminder disable
- /evadmin events enable
- /evadmin events disable
- /evcreate {name} {location} {@required} {private (optional, default false)}
- /evedit {eventID} minimum {min. required accepts}
- /evedit {eventID} invite {required/optional} {@user}
- /evedit {eventID} remove {@user}
- /evedit {eventID} location {location}
- /evedit {eventID} description {description}
- /evedit {eventID} title {title}
- /evedit {eventID} start {start}
- /evedit {eventID} end {end}
- /evedit {eventID} cancel
- /evedit {eventID} confirm
- /evedit {eventID} reminder add {date} {time} {type (optional, default channel)}
- /evedit {eventID} reminder remove all
- /evedit {eventID} reminder remove {date} {time} {type (optional, default channel)}
- /evinvites list
- /evinvites accept {eventID}
- /evinvites maybe {eventID}
- /evinvites decline {eventID}
- /evevent {eventID}
- /evevent {eventID} join